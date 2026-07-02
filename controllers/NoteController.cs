using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelloDocker.Data;
using HelloDocker.Models;

namespace HelloDocker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NoteController : ControllerBase
{
    private readonly AppDbContext _context;

    public NoteController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
    {
        return await _context.Notes.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Note>> CreateNote(Note note)
    {
        _context.Notes.Add(note);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetNotes), new { id = note.Id }, note);
    }
}
