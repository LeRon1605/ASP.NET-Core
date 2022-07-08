using System;

namespace Repository_And_UnitOfWork.Models.ViewModel
{
    public class ErrorModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
