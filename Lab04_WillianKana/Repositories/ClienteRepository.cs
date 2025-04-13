using Lab04_WillianKana.Data;
using Lab04_WillianKana.Entities;
using Lab04_WillianKana.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lab04_WillianKana.Repositories;

public class ClienteRepository : Repository<Cliente>, IClienteRepository
{
    private readonly ApplicationDbContext _context;

    public ClienteRepository(ApplicationDbContext _context) : base(_context)
    {
        this._context = _context;
    }
    
}