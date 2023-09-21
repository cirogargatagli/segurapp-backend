using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SegurApp.Domain
{
    public class QueryParameters
    {
        public int Id { get; set; }
        public string? Email { get; set; }
    }
}
