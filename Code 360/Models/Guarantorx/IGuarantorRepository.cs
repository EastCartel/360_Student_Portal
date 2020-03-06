using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Models.Guarantorx
{
    public interface IGuarantorRepository
    {
        Guarantors GetGuarantor(int Id);

        IEnumerable<Guarantors> GetAllGuarantor();

        Guarantors AddGuarantors(Guarantors guarantors);

        Guarantors Remove(int Id);

        Guarantors UpdateGuarantors(Guarantors guarantorsUpdate);
    }
}
