﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EksamenAPI.Data;
using EksamenAPI.Models;

namespace EksamenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly ModelContext _context;

        public AssignmentsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Assignments
        [HttpGet]
        public IEnumerable<Assignment> GetAssignments()
        {
            return _context.Assignments;
        }

        // GET: api/Assignments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = await _context.Assignments.FindAsync(id);

            if (assignment == null)
            {
                return NotFound();
            }

            return Ok(assignment);
        }

        // PUT: api/Assignments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignment([FromRoute] int id, [FromBody] Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignment.AssignmentId)
            {
                return BadRequest();
            }

            _context.Entry(assignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Assignments
        [HttpPost]
        public async Task<IActionResult> PostAssignment([FromBody] Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignment", new { id = assignment.AssignmentId }, assignment);
        }

        // DELETE: api/Assignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();

            return Ok(assignment);
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.AssignmentId == id);
        }
    }
}