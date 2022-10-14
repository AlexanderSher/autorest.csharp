// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class BuildContext
    {
        protected LibraryRef BaseLibraryRef { get; }

        public BuildContext(CodeModel codeModel, SourceInputModel? sourceInputModel)
        {
            BaseLibraryRef = new LibraryRef();
            CodeModel = codeModel;
            SchemaUsageProvider = new SchemaUsageProvider(codeModel);
            SourceInputModel = sourceInputModel;
        }

        public OutputLibrary? BaseLibrary => BaseLibraryRef.Library;

        public CodeModel CodeModel { get; }
        public SchemaUsageProvider SchemaUsageProvider { get; }
        public string DefaultName => CodeModel.Language.Default.Name;
        public string DefaultNamespace => Configuration.Namespace ?? DefaultName;
        public string DefaultLibraryName => Configuration.LibraryName ?? DefaultName;
        public SourceInputModel? SourceInputModel { get; }
        public virtual TypeFactory TypeFactory { get; } = null!;

        internal class LibraryRef
        {
            public OutputLibrary? Library { get; set; }
        }
    }
}
