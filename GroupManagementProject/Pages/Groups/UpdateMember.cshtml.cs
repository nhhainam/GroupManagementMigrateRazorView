using GroupManagementProject.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GroupManagementProject.Pages.Groups
{
    public class UpdateMemberModel : PageModel
    {
        GroupManagementContext context = new GroupManagementContext();
        public void OnGet(string userid, string groupid)
        {
            var username = HttpContext.Session.GetString("username");
            User curUser = context.Users.SingleOrDefault(u => u.Username == username);

            User user = context.Users.SingleOrDefault(u => u.UserId == int.Parse(userid));
            List<Role> roles = context.Roles.ToList();
            List<Member> members = context.Members.Include(m => m.Group).Include(m => m.Role).Include(m => m.User).Where(m => m.GroupId == int.Parse(groupid) && m.Status == true).ToList();
            foreach (Member member in members)
            {
                if (member.UserId == user.UserId)
                {
                    ViewData["usermember"] = member;
                }
            }


            ViewData["curUser"] = curUser;
            ViewData["user"] = user;
            ViewData["roles"] = roles;
        }

        public void OnPost(string role, string userid, string groupid)
        {
            var username = HttpContext.Session.GetString("username");
            User curUser = context.Users.SingleOrDefault(u => u.Username == username);
            User user = context.Users.SingleOrDefault(u => u.UserId == int.Parse(userid));

            List<Member> members = context.Members.Include(m => m.Group).Include(m => m.Role).Include(m => m.User).Where(m => m.GroupId == int.Parse(groupid) && m.Status == true).ToList();
            foreach (Member member in members)
            {
                if (member.UserId == int.Parse(userid))
                {
                    //context.Entry(member).CurrentValues.SetValues(role);
                    member.RoleId = int.Parse(role);
                    context.SaveChanges();
                    ViewData["usermember"] = member;
                }
            }
            context.SaveChanges();
            List<Role> roles = context.Roles.ToList();
            

            ViewData["curUser"] = curUser;
            ViewData["user"] = user;
            ViewData["roles"] = roles;
        }
    }
}
