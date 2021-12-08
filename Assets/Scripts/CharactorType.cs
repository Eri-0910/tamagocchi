public class CharactorType
{
    public CharactorTypeId id;
    public string name;

    public CharactorType(int id)
    {
        this.id = (CharactorTypeId) id;
        this.name = CharactorTypeIdToString(this.id);
    }
    public enum CharactorTypeId
    {
        normal = 0,
        cto = 1,
        muscular = 2,
        muscularCto = 3
    }

    public CharactorTypeId StringToCharactorTypeId(string charactorType){
        switch (charactorType)
        {
            case "normal":
                return CharactorTypeId.normal;
            case "cto":
                return CharactorTypeId.cto;
            case "muscular":
                return CharactorTypeId.muscular;
            case "muscularCto":
                return CharactorTypeId.muscularCto;
            default:
                return CharactorTypeId.normal;
        }
    }

    public string CharactorTypeIdToString(CharactorTypeId id){
        switch (id)
        {
            case CharactorTypeId.normal:
                return "normal";
            case CharactorTypeId.cto:
                return "cto";
            case CharactorTypeId.muscular:
                return "muscular";
            case CharactorTypeId.muscularCto:
                return "muscularCto";
            default:
                return "normal";
        }
    }

}
