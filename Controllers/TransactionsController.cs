﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using contasoft_api.Data;
using contasoft_api.Models;
using contasoft_api.DTOs;
using contasoft_api.DTOs.Outputs;
using System.ComponentModel.Design;
using contasoft_api.DTOs.Inputs;
using Microsoft.AspNetCore.Authorization;

namespace contasoft_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ContaSoftDbContext _context;

        public TransactionsController(ContaSoftDbContext context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransaction()
        {
          if (_context.Transaction == null)
          {
              return NotFound();
          }
            return await _context.Transaction.ToListAsync();
        }

        // GET: api/Transactions/5
   
        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetTransactionByCompany(int companyId)
        {
            var response = new DefaultResponse();
            List<TransactionOutput> transactionsList = new List<TransactionOutput>();
            if (_context.Transaction == null)
          {
              return NotFound();
          }
            var transactions = await _context.Transaction.Where(x=>x.CompanyId == companyId).OrderByDescending(x=>x.CreateDate).ToListAsync();

            if (transactions == null)
            {
                return NotFound();
            }

            transactions.ForEach(tran =>
            {
                TransactionOutput output = new TransactionOutput()
                {
                    Id = tran.Id,
                    BankNumberOut = tran.BankNumberOut,
                    BankNumberIn = tran.BankNumberIn,
                    Amount = tran.Amount,
                    NoCheck = tran.NoCheck,
                    Concept = tran.Concept,
                    Tipo = tran.Tipo,
                    TransactionDate = tran.TransactionDate,
                    CompanyId = tran.CompanyId,
                };

                transactionsList.Add(output);
            });

            response.Message = "Success";
            response.StatusCode = 1;
            response.Success = true;
            response.Data = transactionsList;

            return Ok(response);
        }

        // PUT: api/Transactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
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

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTransaction(TransactionInput model)
        {
            var response = new DefaultResponse();
            if (_context.Transaction == null)
          {
              return Problem("Entity set 'ContaSoftDbContext.Transaction'  is null.");
          }


            Transaction transaction = new Transaction()
            {
                Id = model.Id,
                BankNumberOut = model.BankNumberOut,
                BankNumberIn = model.BankNumberIn,
                Amount = model.Amount,
                NoCheck = model.NoCheck,
                Concept = model.Concept,
                Tipo = model.Tipo,
                TransactionDate = model.TransactionDate,
                CompanyId = model.CompanyId,
                UserCode="root",
                CreateDate = DateTime.Now,
                IsActive = true
            };
            _context.Transaction.Add(transaction);
            await _context.SaveChangesAsync();

            response.Message = "Success";
            response.StatusCode = 1;
            response.Success = true;
            

            return Ok(response);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            if (_context.Transaction == null)
            {
                return NotFound();
            }
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionExists(int id)
        {
            return (_context.Transaction?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}