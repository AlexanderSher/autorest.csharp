// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.AI.OpenAI
{
    /// <summary>
    /// Representation of the token counts processed for a completions request.
    /// Counts consider all tokens across prompts, choices, choice alternates, best_of generations, and other consumers.
    /// </summary>
    public partial class CompletionsUsage
    {
        /// <summary> Initializes a new instance of CompletionsUsage. </summary>
        /// <param name="completionTokens"> Number of tokens received in the completion. </param>
        /// <param name="promptTokens"> Number of tokens sent in the original request. </param>
        /// <param name="totalTokens"> Total number of tokens transacted in this request/response. </param>
        internal CompletionsUsage(int completionTokens, int promptTokens, int totalTokens)
        {
            CompletionTokens = completionTokens;
            PromptTokens = promptTokens;
            TotalTokens = totalTokens;
        }

        /// <summary> Number of tokens received in the completion. </summary>
        public int CompletionTokens { get; }
        /// <summary> Number of tokens sent in the original request. </summary>
        public int PromptTokens { get; }
        /// <summary> Total number of tokens transacted in this request/response. </summary>
        public int TotalTokens { get; }
    }
}
