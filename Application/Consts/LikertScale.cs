using Domain.Entities;
using Domain.Enums;

namespace Application.Consts
{
    public static class LikertScale
    {
        public static List<Option> GetAgreementScale()
        {
            return new List<Option>
            ([
                new Option(){ Statement = "Muita frequência", Order = 5, Value = 5 },
                new Option(){ Statement = "Frequentemente", Order = 4, Value = 4 },
                new Option(){ Statement = "Ocasionalmente", Order = 3, Value = 3 },
                new Option(){ Statement = "Raramente", Order = 2, Value = 2 },
                new Option(){ Statement = "Nunca totalmente", Order = 1, Value = 1 },
            ]);
        }

        public static List<Option> GetFrequencyScale()
        {
            return new List<Option>
            ([
                new Option(){ Statement = "Muita frequência", Order = 5, Value = 5 },
                new Option(){ Statement = "Frequentemente", Order = 4, Value = 4 },
                new Option(){ Statement = "Ocasionalmente", Order = 3, Value = 3 },
                new Option(){ Statement = "Raramente", Order = 2, Value = 2 },
                new Option(){ Statement = "Nunca totalmente", Order = 1, Value = 1 },
            ]);
        }

        public static List<Option> GetImportanceScale()
        {
            return new List<Option>
            ([
                new Option(){ Statement = "Muito importante", Order = 5, Value = 5 },
                new Option(){ Statement = "Importante", Order = 4, Value = 4 },
                new Option(){ Statement = "Razoávelmente", Order = 3, Value = 3 },
                new Option(){ Statement = "Pouco importante", Order = 2, Value = 2 },
                new Option(){ Statement = "Sem importância", Order = 1, Value = 1 },
            ]);
        }

        public static List<Option> GetScalePreSet(LikertType type)
        {
            var list = new List<Option>();
            switch (type)
            {
                case LikertType.AgreementScale:
                    list = GetAgreementScale();
                    break;
                case LikertType.ImportanceScale:
                    list = GetImportanceScale();
                    break;
                case LikertType.FrequencyScale:
                    list = GetFrequencyScale();
                    break;
                case LikertType.CustomScale:
                    break;
                default:
                    break;
            }

            return list;
        }
    }
}
