#pragma warning disable IDE0005 // Using directive is unnecessary.
global using Microsoft.EntityFrameworkCore;
global using System.Text.Json;
global using System;
global using System.Collections.Generic;
global using System.Collections.ObjectModel;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.Globalization;
global using System.Linq;
global using System.Linq.Expressions;
global using System.Runtime.Serialization;
global using System.Text;
global using System.Threading.Tasks;
global using System.Diagnostics;

global using Jtbuk.VerticalArchitecture.Common.Db;
global using Jtbuk.VerticalArchitecture.Common.Dto;
global using Jtbuk.VerticalArchitecture.Common.Exceptions;
#pragma warning restore IDE0005 // Using directive is unnecessary.

#if DEBUG
global using Xunit;
global using FluentAssertions;
global using Jtbuk.VerticalArchitecture.TestHelpers;
#endif
