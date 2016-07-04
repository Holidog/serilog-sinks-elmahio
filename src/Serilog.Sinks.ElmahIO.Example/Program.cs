﻿// Copyright 2014 Serilog Contributors
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using Serilog.Context;

namespace Serilog.Sinks.ElmahIO.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger =
                new LoggerConfiguration()
                    .Enrich.WithProperty("Hello", "World")
                    .Enrich.FromLogContext()
                    .WriteTo.ElmahIO(new Guid("a6ac10b1-98b3-495f-960e-424fb18e3caf"))
                    .CreateLogger();

            using (LogContext.PushProperty("LogContext property", "with some value"))
            {
                logger.Error("This is a log message with a {TypeOfProperty} message", "structured");
            }
        }
    }
}
