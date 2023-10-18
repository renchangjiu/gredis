using System.Text.Encodings.Web;
using System.Text.Json;

namespace gredis.Utils;

public static class CC {

    public static readonly JsonSerializerOptions JsonSerializerOptions = new() {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

}