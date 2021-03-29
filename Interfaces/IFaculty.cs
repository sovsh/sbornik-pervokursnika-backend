using System.Collections;
using System.Collections.Generic;

namespace SbornikBackend.Interfaces
{
    public interface IFaculty
    {
        IEnumerable<Faculty> GetAll();

    }
}