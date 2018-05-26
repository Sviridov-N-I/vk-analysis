using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkForm
{
    class vkGroup
    {
        public String groupName;
        public int groupID;
        public vkGroup(String groupName, int groupID)
        {
            this.groupID = groupID;
            this.groupName = groupName;
        }
        public vkGroup() { }


    }
}
