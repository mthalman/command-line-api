﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace System.CommandLine.Help
{
    public sealed class HelpOption : CliOption<bool>
    {
        private CliAction? _action;

        /// <summary>
        /// When added to a <see cref="CliCommand"/>, it configures the application to show help when one of the following options are specified on the command line:
        /// <code>
        ///    -h
        ///    /h
        ///    --help
        ///    -?
        ///    /?
        /// </code>
        /// </summary>
        public HelpOption() : this("--help", new[] { "-h", "/h", "-?", "/?" })
        {
        }

        /// <summary>
        /// When added to a <see cref="CliCommand"/>, it configures the application to show help when given name or one of the aliases are specified on the command line.
        /// </summary>
        public HelpOption(string name, params string[] aliases)
            : base(name, aliases, new CliArgument<bool>(name) { Arity = ArgumentArity.Zero })
        {
            Recursive = true;
            Description = LocalizationResources.HelpOptionDescription();
        }

        /// <inheritdoc />
        public override CliAction? Action 
        { 
            get => _action ??= new HelpAction(); 
            set => _action = value ?? throw new ArgumentNullException(nameof(value));
        }

        internal override bool Greedy => false;

        public override bool Equals(object? obj) => obj is HelpOption;

        public override int GetHashCode() => typeof(HelpOption).GetHashCode();
    }
}