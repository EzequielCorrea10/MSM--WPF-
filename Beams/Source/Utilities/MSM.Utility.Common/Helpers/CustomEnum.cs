using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MSM.Utility.Common.Helpers
{
    /// <summary>Base-class for custom enumerations.</summary>
    /// <typeparam name="TEnum">The type of your subclass</typeparam>
    /// <typeparam name="TValue">The type of the value</typeparam>
    /// <remarks>Hints for implementors: You must ensure that only one instance of each enum-value exists. This is easily reached by 
    /// declaring the constructor(s) private and/or sealing the class and exposing the enum-values as static fields. If you are
    /// implementing them through static getter properties, make sure lazzy initialization is used and that not a new instances 
    /// is returned with every call.</remarks>
    [DebuggerDisplay("{_Name} ({_Value})")]
    public abstract class CustomEnum<TEnum, TValue> : IEquatable<TValue> where TEnum : CustomEnum<TEnum, TValue>
    {

        //Private Fields

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static TEnum[] _Members;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static bool? _CaseSensitive;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static IEqualityComparer<TValue> _ValueComparer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //Hint: assign only in GetMemberByName(..)!
        private static IEqualityComparer<string> _StringComparer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _Name;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private TValue _Value;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _Index = -1;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static bool _IsFirstInstance = true;
        //Constructors

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static Type TClass;

        /// <summary>Called by implementors to create a new instance of TEnum. Important: Seal your class and/or make your constructors private!</summary>
        protected CustomEnum(TValue aValue, Type _TClass)
            : this(aValue, null, null)
        {
            TClass = _TClass;
        }

        /// <summary>Called by implementors to create a new instance of TEnum. Important: Seal your class and/or make your constructors private!</summary>
        protected CustomEnum(TValue aValue)
            : this(aValue, null, null)
        {
        }

        /// <summary>Called by implementors to create a new instance of TEnum. Important: Seal your class and/or make your constructors private!</summary>
        protected CustomEnum(TValue aValue, bool? caseSensitive, IEqualityComparer<TValue> aValueComparer)
        {
            //Assign instance value
            _Value = aValue;
            //Make sure no evil cross subclass is changing our static variable
            if ((!typeof(TEnum).IsAssignableFrom(this.GetType())))
            {
                throw new InvalidOperationException("Internal error in " + this.GetType().Name + "! Change the first type parameter from \"" + typeof(TEnum).Name + "\" to \"" + this.GetType().Name + "\".");
            }
            //Make sure only the first subclass is affecting our static variables
            if ((_IsFirstInstance))
            {
                _IsFirstInstance = false;
                //Assign static variables
                _CaseSensitive = caseSensitive;
                _ValueComparer = aValueComparer;
            }
        }

        //Public Properties

        /// <summary>Returns the name of this CustomEnum-value.</summary>
        public string Name
        {
            get
            {
                //Check whether the name is already assigned
                string myResult = _Name;
                if ((myResult == null))
                {
                    InitMembers();
                    myResult = _Name;
                }
                //Return the name
                return myResult;
            }
        }

        /// <summary>Returns the value of this CustomEnum-value.</summary>
        public TValue Value
        {
            get { return _Value; }
        }

        /// <summary>Returns the index position of this CustomEnum-value.</summary>
        public int Index
        {
            get
            {
                //Check whether the index is already assigned
                int myResult = _Index;
                if ((myResult < 0))
                {
                    InitMembers();
                    myResult = _Index;
                }
                //Return the index
                return myResult;
            }
        }

        //Public Class Properties

        /// <summary>Returns whether the names passed to function <see cref="GetMemberByName(string)" /> are treated case sensitive
        /// or not (using <see cref="StringComparer.Ordinal" /> resp. <see cref="StringComparer.OrdinalIgnoreCase" />).
        /// The default behavior is that they are case-insensitive except there would be two or more entries that would
        /// cause an ambiguity.</summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static bool CaseSensitive
        {
            get
            {
                bool? myResult = _CaseSensitive;
                if ((myResult == null))
                {
                    myResult = InitCaseSensitive();
                    _CaseSensitive = myResult;
                }
                return myResult.Value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Type UnderlyingType
        {
            get { return typeof(TValue); }
        }

        //Public Class Functions

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static TEnum[] GetMembers()
        {
            TEnum[] myMembers = Members;
            TEnum[] myResult = new TEnum[myMembers.Length];
            Array.Copy(myMembers, myResult, myMembers.Length);
            return myResult;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static string[] GetNames()
        {
            TEnum[] myMembers = Members;
            string[] myResult = new string[myMembers.Length];
            for (int i = 0; i <= myMembers.Length - 1; i++)
            {
                myResult[i] = myMembers[i]._Name;
            }
            return myResult;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static TValue[] GetValues()
        {
            TEnum[] myMembers = Members;
            TValue[] myResult = new TValue[myMembers.Length];
            for (int i = 0; i <= myMembers.Length - 1; i++)
            {
                myResult[i] = myMembers[i]._Value;
            }
            return myResult;
        }

        /// <summary>Returns the member of the given name or null if not found. You can check through property
        /// <see cref="CaseSensitive" /> whether <paramref name="aName" /> is treated case-sensitive or not.
        /// If aName is null, an ArgumentNullException is thrown. If the subclass is incorrectly implemented
        /// and has duplicate names defined, a DuplicateNameException is thrown.</summary>
        /// <param name="aName">The name to look up.</param>
        /// <returns>The enum entry or null if not found.</returns>
        /// <remarks>A full duplicate check is performed the first time this method is called.</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static TEnum GetMemberByName(string aName)
        {
            //Check the argument
            if ((aName == null))
                throw new ArgumentNullException("aName");
            //Get the members
            TEnum[] myMembers = Members;
            //Initialize comparer and check whole table for duplicates
            IEqualityComparer<string> myComparer = _StringComparer;
            if ((myComparer == null))
            {
                //Determine the comparer
                myComparer = CaseSensitive ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase;
                //Check for duplicates (happens if the constructor explicitely sets the case-insensitive flag but has two fields that differ only by case,
                //or if the enum has multiple hierarchical subclasses and the overwritten properties do not hide the parent ones (like this is the case 
                //in JScript.NET).
                if ((HasDuplicateNames(myComparer)))
                {
                    throw new DuplicateNameException("Internal error in " + typeof(TEnum).Name + ", the member names are not unique!");
                }
                //If everything is okay, assign the comparer
                _StringComparer = myComparer;
            }
            //Return the first name found
            foreach (TEnum myMember in myMembers)
            {
                if ((myComparer.Equals(myMember._Name, aName)))
                    return myMember;
            }
            //Otherwise return null
            return null;
        }

        /// <summary>Returns the member of the given name or null if not found using the given comparer 
        /// to perform the comparison. If there are no special reasons don't use this method but the
        /// one without the comparer overload as it is optimized to perform the duplicate check only
        /// once and not every time the method is used.</summary>
        /// <param name="aName">The name to look up.</param>
        /// <param name="aComparer">The comparer to use for the equality comparison of the strings.</param>
        /// <returns>The enum entry or null if not found.</returns>
        /// <remarks>The whole list is searched every time this method is called to ensure aName is unique according to the given comparer.</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static TEnum GetMemberByName(string aName, IEqualityComparer<string> aComparer)
        {
            //Check the argument
            if ((aName == null))
                throw new ArgumentNullException("aName");
            //Use optimized method if possible
            if ((aComparer == null))
                return GetMemberByName(aName);
            if ((object.Equals(aComparer, _StringComparer)))
                return GetMemberByName(aName);
            //Get the members
            TEnum[] myMembers = Members;
            //Get the first found member but continue looping
            TEnum myResult = null;
            foreach (TEnum myMember in myMembers)
            {
                if ((aComparer.Equals(myMember._Name, aName)))
                {
                    if ((myResult == null))
                    {
                        myResult = myMember;
                    }
                    else
                    {
                        throw new DuplicateNameException("The name \"" + aName + "\" is not unique according to the given comparer!");
                    }
                }
            }
            //Return the result 
            return myResult;
        }

        /// <summary>Returns the first member of the given value or null if not found. The value to look up 
        /// may also be null. This function uses the value comparer defined by the enumeration (or Object's 
        /// equal method if not defined) to perform the comparison.</summary>
        /// <param name="aValue">The value to look up (null is valid be null).</param>
        /// <returns>The enum entry or null if not found.</returns>
        /// <remarks>The duplicate check is performed only the first time if successful.</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static TEnum GetMemberByValue(TValue aValue)
        {
            return GetMemberByValue(aValue, _ValueComparer);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static TEnum GetMemberByValue(TValue aValue, IEqualityComparer<TValue> aValueComparer)
        {
            //Get the members
            TEnum[] myMembers = Members;
            //Immediately return the member if the values equal
            if ((aValueComparer == null))
            {
                //Using the default comparer
                foreach (TEnum myMember in myMembers)
                {
                    if ((object.Equals(myMember._Value, aValue)))
                        return myMember;
                }
            }
            else
            {
                //Using the given comparer
                foreach (TEnum myMember in myMembers)
                {
                    //Immediately return the member if the values equal
                    if ((aValueComparer.Equals(myMember._Value, aValue)))
                        return myMember;
                }
            }
            //Return null if not found
            return null;
        }

        /// <summary>Always implicitely allow to cast into the value type (like this is the case with standard 
        /// .NET enumerations).</summary>
        public static implicit operator TValue(CustomEnum<TEnum, TValue> value)
        {
            if ((value == null))
                throw new ArgumentNullException("value");
            return value.Value;
        }

        //Framework Properties

        public override string ToString()
        {
            return Name;
        }

        //Framework Methods

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual bool Equals(TValue other)
        {
            IEqualityComparer<TValue> myComparer = _ValueComparer;
            if ((myComparer == null))
            {
                return object.Equals(this._Value, other);
            }
            return myComparer.Equals(this._Value, other);
        }

        //Private Properties

        private static TEnum[] Members
        {
            get
            {
                TEnum[] myResult = _Members;
                if ((myResult == null))
                {
                    myResult = PrivateGetMembers();
                    _Members = myResult;
                }
                return myResult;
            }
        }

        //Private Methods

        private static void InitMembers()
        {
            TEnum[] myDummy = Members;
        }

        private static TEnum[] PrivateGetMembers()
        {
            List<TEnum> myList = new List<TEnum>();
            AddFields(myList);
            AddGetters(myList);
            return myList.ToArray();
        }

        private static void AddFields(List<TEnum> aList)
        {
            BindingFlags myFlags = (BindingFlags.Static | BindingFlags.Public);

            List<FieldInfo> myFields = typeof(TEnum).GetFields(myFlags).ToList();
            if (TClass != null)
            {
                myFields.AddRange(TClass.GetFields(myFlags));
            }
            foreach (FieldInfo myField in myFields)
            {
                if ((object.ReferenceEquals(myField.FieldType, typeof(TEnum))) && (myField.IsLiteral || myField.IsInitOnly))
                {
                    TEnum myEntry = (TEnum)myField.GetValue(null);
                    AddEntry(myEntry, myField.Name, aList);
                }
            }
        }

        private static void AddGetters(List<TEnum> aList)
        {
            BindingFlags myFlags = (BindingFlags.Static | BindingFlags.Public | BindingFlags.GetProperty);
            List<PropertyInfo> myProperties = typeof(TEnum).GetProperties(myFlags).ToList();
            if (TClass != null)
            {
                myProperties.AddRange(TClass.GetProperties(myFlags));
            }
            foreach (PropertyInfo myProperty in myProperties)
            {
                if ((object.ReferenceEquals(myProperty.PropertyType, typeof(TEnum))) && (myProperty.CanRead) && (!myProperty.CanWrite) && (myProperty.GetIndexParameters().Length == 0))
                {
                    //Invoke the property twice and check whether the same instance is returned (it is a requirement)
                    TEnum myEntry = (TEnum)myProperty.GetValue(null, null);
                    TEnum myEntry2 = (TEnum)myProperty.GetValue(null, null);
                    if ((!object.ReferenceEquals(myEntry, myEntry2)))
                    {
                        throw new InvalidOperationException("Internal error in " + typeof(TEnum).Name + "! Property " + myProperty.Name + " returned different instances when invoked multiple times. Ensure always the same instance is returned.");
                    }
                    //Add the entry
                    AddEntry(myEntry, myProperty.Name, aList);
                }
            }
        }

        private static void AddEntry(TEnum aValue, string aName, List<TEnum> aList)
        {
            //Check for instance conflicts
            if ((aValue._Name != null))
            {
                throw new InvalidOperationException("Internal error in " + typeof(TEnum).Name + "! It's invalid to assign the same instance to two fields (a conflict arises when assigning name and index to the instance).");
            }
            //Set the name and index
            aValue._Name = aName;
            aValue._Index = aList.Count;
            //Add to the list
            aList.Add(aValue);
        }

        private static bool InitCaseSensitive()
        {
            return HasDuplicateNames(StringComparer.OrdinalIgnoreCase);
        }

        private static bool HasDuplicateNames(IEqualityComparer<string> aComparer)
        {
            TEnum[] myMembers = Members;
            Dictionary<string, TEnum> myDict = new Dictionary<string, TEnum>(aComparer);
            try
            {
                foreach (TEnum myEntry in myMembers)
                {
                    myDict.Add(myEntry._Name, myEntry);
                }
            }
            catch
            {
                return true;
            }
            return false;
        }
    }
}
