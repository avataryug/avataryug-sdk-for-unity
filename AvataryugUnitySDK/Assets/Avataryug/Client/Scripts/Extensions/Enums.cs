namespace Com.Avataryug
{
    /// <summary>
    /// Used Platfroms enum for request the Platfroms in api
    /// </summary>

    public enum Platfroms
    {
        Android = 0,
        iOS = 1,
        Web = 2,
        Steam = 3,
        Meta = 4,
        Xbox = 5,
        Playstation = 6,
        Custom = 7,
    }

    /// <summary>
    /// Used InstanceType enum for request the InstanceType in api
    /// </summary>
    public enum InstanceType
    {
        CONTAINER,
        BUNDLE,
        ITEM,
        CURRENCY
    }

    /// <summary>
    /// Used Gender enum for request the Gender in api
    /// </summary>
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Common = 3
    }

    /// <summary>
    /// Used PropColorType enum for selecting color category
    /// </summary>
    public enum PropColorType
    {
        HairColor,
        EyebrowColor,
        FacialHairColor,
        LipColor,
    }

    /// <summary>
    /// Used SortType enum for sorting received data in given format
    /// </summary>
    public enum SortType
    {
        AsReceived,
        HightToLow,
        LowToHigh
    }

    /// <summary>
    /// Used ModelParent enum for switching  between multiple parent
    /// </summary>
    public enum ModelParent
    {
        ONBOARD,
        HOME,
        CUSTOMIZE,
        NONE
    }
}