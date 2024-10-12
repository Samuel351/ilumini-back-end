using Domain.Entities;

namespace Application.Consts
{
    public static class LikertScale
    {
        public static HashSet<Option> AgreementScale { get; } = new HashSet<Option>(
        [
            new Option(){ Statement = "Concordo totalmente", Order = 5, Value = 5 },
            new Option(){ Statement = "Concordo", Order = 4, Value = 4 },
            new Option(){ Statement = "Indeciso", Order = 3, Value = 3 },
            new Option(){ Statement = "Discordo", Order = 2, Value = 2 },
            new Option(){ Statement = "Discordo totalmente", Order = 1, Value = 1 },
        ]);

        public static HashSet<Option> FrequencyScale { get; set; } = new HashSet<Option>([
            new Option(){ Statement = "Muita frequência", Order = 5, Value = 5 },
            new Option(){ Statement = "Frequentemente", Order = 4, Value = 4 },
            new Option(){ Statement = "Ocasionalmente", Order = 3, Value = 3 },
            new Option(){ Statement = "Raramente", Order = 2, Value = 2 },
            new Option(){ Statement = "Nunca totalmente", Order = 1, Value = 1 },
        ]);

        public static HashSet<Option> ImportanceScale { get; set; } = new HashSet<Option>([
            new Option(){ Statement = "Muito importante", Order = 5, Value = 5 },
            new Option(){ Statement = "Importante", Order = 4, Value = 4 },
            new Option(){ Statement = "Razoávelmente", Order = 3, Value = 3 },
            new Option(){ Statement = "Pouco importante", Order = 2, Value = 2 },
            new Option(){ Statement = "Sem importância", Order = 1, Value = 1 },
        ]);
    }
}
