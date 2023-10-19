using System.Text.Encodings.Web;
using System.Text.Json;

namespace gredis.Utils;

public static class CC {

    public static readonly JsonSerializerOptions JsonSerializerOptions = new() {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    public const string GithubRepoPath = "https://github.com/renchangjiu/gredis";

    public const string Version = "0.0.1";

}