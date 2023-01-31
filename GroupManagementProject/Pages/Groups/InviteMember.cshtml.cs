using GroupManagementProject.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Text.RegularExpressions;
using Group = GroupManagementProject.Entity.Group;

namespace GroupManagementProject.Pages.Groups
{
    public class InviteMemberModel : PageModel
    {
        GroupManagementContext context = new GroupManagementContext();
        public void OnGet(string groupid)
        {
            var username = HttpContext.Session.GetString("username");
            User curUser = context.Users.SingleOrDefault(u => u.Username == username);
            List<Role> roles = context.Roles.ToList();
            Group group = context.Groups.SingleOrDefault(g => g.GroupId == int.Parse(groupid));

            ViewData["curUser"] = curUser;
            ViewData["group"] = group;
            ViewData["roles"] = roles;
        }
        public void OnPost(string groupid, string username, string role)
        {
            var curUsername = HttpContext.Session.GetString("username");
            User curUser = context.Users.SingleOrDefault(u => u.Username == curUsername && u.Status == true);
            User userFound = context.Users.SingleOrDefault(u => u.Username == username && u.Status == true);
            Group group = context.Groups.SingleOrDefault(g => g.GroupId == int.Parse(groupid));
            List<Role> roles = context.Roles.ToList();
            Member member = context.Members.SingleOrDefault(m => m.GroupId == int.Parse(groupid) && m.User.Username.Equals(username) && m.State == 0 && m.Status == true);

            ViewData["curUser"] = curUser;
            ViewData["group"] = group;
            ViewData["roles"] = roles;

            if (userFound != null && member == null)
            {
                Member memberadd = new Member { GroupId = int.Parse(groupid), RoleId = int.Parse(role), UserId = userFound.UserId, Status = true, State = 0 };
                context.Members.Add(memberadd);
                context.SaveChanges();
                ViewData["MessInvite"] = "Invite has been sent";
            } else if (userFound == null ) {
                ViewData["MessInvite"] = "User not exist";
            } else if (member != null) {
                ViewData["MessInvite"] = "Member already in group";
            } else
            {
                ViewData["MessInvite"] = "Login failed";
            }

        }
    }
}
