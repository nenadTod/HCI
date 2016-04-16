using MapControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HCI_Project.Controls
{
    public class ResourcePushpin : Pushpin
    {
        //private bool isDragging = false;
        private Point startPoint;
        private ResourceLocation location;

        public ResourceLocation Location
        {
            get { return location; }
            set { location = value; }
        }

        public ResourcePushpin(ResourceLocation location)
        {
            this.MouseRightButtonDown += ResourcePushpinMouseRightButtonDown;
            this.PreviewMouseLeftButtonDown += SpeciesMouseLeftButtonDown;
            this.PreviewMouseMove += SpeciesMouseMove;
            this.GiveFeedback += OnGiveFeedback;
            this.location = location;
        }

        void ResourcePushpinMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ContextMenu menu = new ContextMenu();

            MenuItem removeButton = new MenuItem();
            removeButton.Header = "Remove pin";
            removeButton.Click += RemovePinClick;

            menu.Items.Add(removeButton);
            menu.PlacementTarget = this;
            menu.IsOpen = true;
        }

        void RemovePinClick(object sender, RoutedEventArgs e)
        {
            var command = new RemoveCommand(this);
            CommandManager.Instance.DoCommand(command);
        }

        private void SpeciesMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
            e.Handled = true;
        }

        private void SpeciesMouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {

                DataObject data = new DataObject();

                data.SetData(DataFormats.StringFormat, this.Uid);
                data.SetData(typeof(ResourcePushpin), this);

                DragDrop.DoDragDrop(this, data, DragDropEffects.Move | DragDropEffects.Link);
            }
        }

        private void OnGiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

            if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.UpArrow);
            }
            else if(e.Effects.HasFlag(DragDropEffects.Link))
            {
                Mouse.SetCursor(Cursors.Pen);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }

    }
}
