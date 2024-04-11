namespace CLINICAL.Application.UseCase.Commons.Bases
{
    public class BaseResponse<T>
    {
        public bool IsSuccess {  get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public IEnumerable<BaseError>? Errors { get; set; }
    }

    /*
     {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ClinicalConexion": "Data Source=192.168.1.106;Database=CLINICAL;User Id=sa; Password=sql; TrustServerCertificate=True;"
  }
}

     */
}
