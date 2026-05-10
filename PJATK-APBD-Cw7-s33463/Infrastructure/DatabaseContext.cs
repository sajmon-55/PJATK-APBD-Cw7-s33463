using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s33463.Models;

namespace PJATK_APBD_Cw7_s33463.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{

}