using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Project.Commands
{
    class RemoveTagsCommand : Command
    {
        Tag tag = new Tag();
        List<KeyValuePair<string, Tag_Species>> savedTagSpecies = new List<KeyValuePair<string, Tag_Species>>();


        public RemoveTagsCommand(Tag t)
        {
            this.tag = t;
        }

        public override void Perform()
        {
            var dBE = DataBase.Instance().DataEnteties;
            var tagSpecies = (from t in dBE.Tag_Species where t.tag_id == tag.id select t).ToList();

            foreach (var ts in tagSpecies)
            {
                savedTagSpecies.Add(new KeyValuePair<string, Tag_Species>(ts.sp_id, ts));
            }

            dBE.Tag_Species.RemoveRange(tagSpecies);
            dBE.Tag.Remove(tag);

            dBE.SaveChanges();
        }

        public override void Rollback()
        {
            var dBE = DataBase.Instance().DataEnteties;

            foreach (var ts in savedTagSpecies)
            {
                ts.Value.sp_id = ts.Key;
                ts.Value.Tag = tag;
            }

            dBE.Tag.Add(tag);
            dBE.Tag_Species.AddRange(from l in savedTagSpecies select l.Value);

            dBE.SaveChanges();
        }

        public override string description
        {
            get { return "Remove Tag"; }
        }
    }
}
