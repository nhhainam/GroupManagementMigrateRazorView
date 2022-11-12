using GroupManagementProject.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GroupManagementProject.Pages.Groups
{
    public class GroupDetailModel : PageModel
    {
        GroupManagementContext context = new GroupManagementContext();
        public void OnGet(string groupid)
        {
            var username = HttpContext.Session.GetString("username");
            User user = context.Users.SingleOrDefault(u => u.Username == username);
            Group group = context.Groups.SingleOrDefault(g => g.GroupId == int.Parse(groupid));

            List<Member> members = context.Members.Include(m => m.Group).Include(m => m.Role).Include(m => m.User).Where(m => m.GroupId == int.Parse(groupid) && m.Status == true && m.State == 1).ToList();
            foreach (Member member in members)
            {
                if(member.UserId == user.UserId)
                {
                    ViewData["usermember"] = member;
                }
            }
            
            ViewData["user"] = user;
            ViewData["group"] = group;
            ViewData["members"] = members;
        }

        public void OnPostRemoveMember(string userid, string groupid)
        {
            List<Member> _members = context.Members.Where(m => m.UserId == int.Parse(userid) && m.GroupId == int.Parse(groupid)).ToList();
            foreach(Member m in _members)
            {
                m.Status = false;
            }

            context.SaveChanges();


            var username = HttpContext.Session.GetString("username");
            User user = context.Users.SingleOrDefault(u => u.Username == username);
            Group group = context.Groups.SingleOrDefault(g => g.GroupId == int.Parse(groupid));

            List<Member> members = context.Members.Include(m => m.Group).Include(m => m.Role).Include(m => m.User).Where(m => m.GroupId == int.Parse(groupid) && m.Status == true && m.State == 1).ToList();
            foreach (Member member in members)
            {
                if (member.UserId == user.UserId)
                {
                    ViewData["usermember"] = member;
                }
            }
            ViewData["user"] = user;
            ViewData["group"] = group;
            ViewData["members"] = members;
        }
    }
}
