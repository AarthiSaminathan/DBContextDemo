using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DbDemo.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StudentController:ControllerBase
    {
        
    
        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
        }

        // // GET: api/TodoItems
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        // {
        //     return await _context.Student.ToListAsync();
        // }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public Student GetId(long id)
        {
            Console.WriteLine("Find Student Whose Student Id: 1");
                var student = _context.Student.Find(id);

        _context.SaveChanges();
        Console.WriteLine($"Context Object Tracking Changes of {_context.ChangeTracker.Entries().Count()} Entities");
                DisplayTrackedEntities(_context.ChangeTracker);
                return student;
        }
        


                 private static void DisplayTrackedEntities(ChangeTracker changeTracker)
        {
            // Gets the DbEntityEntry objects for all the entities tracked by the context object.
            var entries = changeTracker.Entries();
            foreach (var entry in entries)
            {
                Console.WriteLine($"\nEntity Name: {entry.Entity.GetType().FullName}");
                Console.WriteLine($"Entity State: {entry.State}");
            }
            Console.WriteLine("\n---------------------------------------");
        }
        // public async Task<ActionResult<Student>> GetStudent(long id)
        // {
        //     var student = await _context.Student.FindAsync(id);

        //     if (student == null)
        //     {
        //         return NotFound();
        //     }

        //     return student;

           
        // }

        

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutStudent(long id, Student student)
        // {
        //     if (id != student.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(student).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!StudentExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // // POST: api/TodoItems
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Student>> PostStudent(Student student)
        // {
        //     _context.Student.Add(student);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        // }

        // // DELETE: api/TodoItems/5
         [HttpDelete("{id}")]
    public Student ReStudent(long id){
        {
         Console.WriteLine("Delete Student");

         var student = (from s in _context.Student where s.Id == 
            5 select s).SingleOrDefault<Student>();

         _context.Student.Remove(student);
         Console.WriteLine("");

         Console.WriteLine("Context tracking changes of {0} entity.", 
           _context.ChangeTracker.Entries().Count());
         var entries = _context.ChangeTracker.Entries();
         DisplayTrackedEntities(_context.ChangeTracker);
                return student;
        }
    }
        
        // public async Task<IActionResult> DeleteStudent(long id)
        // {
        //     var student = await _context.Student.FindAsync(id);
        //     if (student == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Student.Remove(student);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool StudentExists(long id)
        // {
        //     return _context.Student.Any(e => e.Id == id);
        // }
    }
    }

