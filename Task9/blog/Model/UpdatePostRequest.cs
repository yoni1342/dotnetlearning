using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Model
{
    public class UpdatePostRequest
    {
        public string? Title { get; set; } = "";
        public string? Content { get; set; } = "";

    }
}