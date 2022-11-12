using GroupManagementProject.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroupManagementProject.Pages.Projects
{
    public class AddProjectModel : PageModel
    {
        GroupManagementContext context = new GroupManagementContext();
        public void OnGet(string groupid)
        {
            var username = HttpContext.Session.GetString("username");
            User user = context.Users.SingleOrDefault(u => u.Username == username);
            Group group = context.Groups.SingleOrDefault(g => g.GroupId == int.Parse(groupid));

            ViewData["group"] = group;
            ViewData["user"] = user;
        }

        public void OnPost(string projectname, string description, string groupid)
        {
            var username = HttpContext.Session.GetString("username");
            User user = context.Users.SingleOrDefault(u => u.Username == username);
            Group group = context.Groups.SingleOrDefault(g => g.GroupId == int.Parse(groupid));
            ViewData["user"] = user;
            ViewData["group"] = group;

            Project project = new Project();
            project.ProjectName = projectname;
            project.Description = description;
            project.Createdate = DateTime.Now;
            project.Group = group;
            project.Status = true;
            context.Projects.Add(project);
            context.SaveChanges();

            ViewData["MessAddProject"] = "Add Project successfully";
        }
    }
}
