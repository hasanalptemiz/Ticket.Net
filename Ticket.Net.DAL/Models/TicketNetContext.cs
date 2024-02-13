using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ticket.Net.DAL.Models
{
    internal class TicketNetContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-9D3D7OQ\\SQLEXPRESS;Database=TicketNet;Trusted_Connection=True;");
        }
    }
}