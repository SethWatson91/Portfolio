using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nursing_Student_Vetting.Models;

namespace Nursing_Student_Vetting.Controllers
{
    public class ClassController : Controller
    {
        private readonly NursingStudentContext _context;
        private List<Class> classes;

        public ClassController(NursingStudentContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(List));
        }

        public IActionResult List()
        {
            List<Class> classes = _context.Classes.ToList();
            return View(classes);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return View(new Class()); // new class
            }

            Class? classes = _context.Classes.Find(id);
            if (classes == null)
            {
                return NotFound();
            }

            return View(classes);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Class classItem)
        {
            if (ModelState.IsValid)
            {
                bool exists = await _context.Classes.AnyAsync(p => p.ClassID == classItem.ClassID && p.CategoryPrefix == classItem.CategoryPrefix);

                if (!exists)        // if student is new
                {
                    _context.Classes.Add(classItem);
                }
                else
                {
                    _context.Classes.Update(classItem);  // update existing student
                }
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Student = classItem;

                return View("List");
            }
        }

        [HttpPost] // basic delete action
        public IActionResult Delete(int id)
        {
            try
            {

                var classItem = _context.Classes.FirstOrDefault(p => p.ClassID == id);
                if (classItem == null)
                {
                    return NotFound();
                }
                String categoryPrefix = classItem.CategoryPrefix;

                var studentClasses = _context.StudentClasses.Where(sc => sc.ClassID == id && sc.CategoryPrefix == categoryPrefix);
                _context.StudentClasses.RemoveRange(studentClasses);

                _context.Classes.Remove(classItem);
                _context.SaveChanges();

                return RedirectToAction(nameof(List));
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message} - {ex.StackTrace}");
            }
            
        }
    }
}
