using GroupManagementProject.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using Group = GroupManagementProject.Entity.Group;

namespace GroupManagementProject.Pages.Groups
{
    public class EditGroupModel : PageModel
    {
        GroupManagementContext context = new GroupManagementContext();
        public void OnGet(string groupid)
        {
            var username = HttpContext.Session.GetString("username");
            User curUser = context.Users.SingleOrDefault(u => u.Username == username);
            Group group = context.Groups.SingleOrDefault(g => g.GroupId == int.Parse(groupid));

            ViewData["curUser"] = curUser;
            ViewData["group"] = group;
        }

        public Boolean CheckGroupName(string name)
        {
            try
            {
                var groupname = context.Groups.Where(g => g.GroupName.Equals(name));
                return groupname.ToList().Count() != 0;
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                return false;
            }
        }
        public void OnPost(string grId, string groupname, string description, string purpose, string state)
        {

            var username = HttpContext.Session.GetString("username");
            User curUser = context.Users.SingleOrDefault(u => u.Username == username);
            Group group = context.Groups.SingleOrDefault(g => g.GroupId == int.Parse(grId));
            ViewData["curUser"] = curUser;
            ViewData["group"] = group;

            int privateOrPublic;
            Boolean isExist = CheckGroupName(groupname);
            if (isExist == true)
            {
                ViewData["MessAddGroup"] = "Group name duplicate";
            }

            else
            {
                group.GroupName = groupname;
                group.Description = description;
                if (state.Equals("Private"))
                {
                    privateOrPublic = 0;
                }
                else
                {
                    privateOrPublic = 1;
                }
                group.State = privateOrPublic;
                group.Purpose = purpose;
                group.Status = true;
                context.SaveChanges();


                ViewData["MessEditGroup"] = "Edit group successfully";
            }
        }
    }
}
