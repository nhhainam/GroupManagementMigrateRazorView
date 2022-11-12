using GroupManagementProject.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GroupManagementProject.Pages.Projects
{
    public class ViewProjectModel : PageModel
    {
        GroupManagementContext context = new GroupManagementContext();
        public void OnGet(string groupid)
        {
            var username = HttpContext.Session.GetString("username");
            User user = context.Users.SingleOrDefault(u => u.Username == username && u.Status == true);
            Member member = context.Members.FirstOrDefault(m => m.UserId == user.UserId && m.Group.GroupId == int.Parse(groupid) && m.Status == true);
            List<Project> projects = context.Projects.Include(p => p.Group.Members).Where(p => p.Group.Members.Contains(member) && p.GroupId == int.Parse(groupid) && p.Status == true).ToList();
            Group group = context.Groups.SingleOrDefault(g => g.GroupId == int.Parse(groupid));

            ViewData["group"] = group;
            ViewData["user"] = user;
            ViewData["projects"] = projects;
        }

        public void OnPostRemoveProject(string projectid)
        {
            Project project = context.Projects.SingleOrDefault(p => p.ProjectId == int.Parse(projectid));
            project.Status = false;
            context.SaveChanges();


            ViewData["MessProjectRemove"] = "Remove Project successfully";


            var username = HttpContext.Session.GetString("username");
            User user = context.Users.SingleOrDefault(u => u.Username == username);
            Member member = context.Members.SingleOrDefault(m => m.UserId == user.UserId);
            List<Project> projects = context.Projects.Include(x => x.Group.Members).Where(p => p.Group.Members.Contains(member)).Where(p => p.Status == true).ToList();
            ViewData["user"] = user;
            ViewData["projects"] = projects;
        }
    }
}
