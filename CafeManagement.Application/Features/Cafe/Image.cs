using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Features.Cafe;

public sealed record Image(Byte[] Bytes, string ContentType);
