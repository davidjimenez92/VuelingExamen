using CustomValidations;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VuelingExamen.Distributed.WebServices.Contracts
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    [ValidationBehavior]
    public interface IVuelingWebService
    {

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        bool Add([NotNullValidator(MessageTemplate = "List is null")] IEnumerable<string> data);
    }
}
