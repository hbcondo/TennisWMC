using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.MediaCenter.UI;

namespace TennisWMC
{
    public class Model : ModelItem
    {
        public Model()
        {
            List<string> items = new List<string>();
            items.Add("Hello");
            items.Add("World");
            items.Add("Once");
            items.Add("Again :)");
            SpinnerItems.Options = items;

            EditableItem.Value = "Hello! :)";
            CheckBoxItem.Description = "Checkbox title";

            DirectoryTreeNode node1 = new DirectoryTreeNode("C:\\", "C:\\", TreeView);
            TreeView.ChildNodes.Add(node1);

        }

        private BooleanChoice _checkBoxItem = new BooleanChoice();
        private Choice _spinnerItems = new Choice();
        private ArrayListDataSet _menuItems = new ArrayListDataSet();
        private EditableText _editableItem = new EditableText();
        private TreeView _treeView = new TreeView();

        public EditableText EditableItem
        {
            get 
            {
                if (_editableItem == null)
                {
                    _editableItem = new EditableText();
                }
                return _editableItem;
            }
            set { _editableItem = value; }
        }
        public Choice SpinnerItems
        {
            get
            {
                if (_spinnerItems == null)
                {
                    _spinnerItems = new Choice();
                    List<string> stringItems = new List<string>();
                    stringItems.Add("Hello");
                    stringItems.Add("World");
                    stringItems.Add("Test123");
                    _spinnerItems.Options = stringItems;
                }
                return _spinnerItems; 
            }
            set { _spinnerItems = value; }
        }
        public ArrayListDataSet MenuItems
        {
            get
            {
                if (_menuItems == null)
                {
                    _menuItems = new ArrayListDataSet();                   
                    _menuItems.Add("Hello");
                    _menuItems.Add("World");
                    _menuItems.Add("Test123");
                }
                return _menuItems;
            }
            set { _menuItems = value; }
        }
        public BooleanChoice CheckBoxItem
        {
            get 
            {
                if (_checkBoxItem == null)
                {
                    _checkBoxItem = new BooleanChoice();
                }
                return _checkBoxItem; 
            }
            set { _checkBoxItem = value; }
        }
        public TreeView TreeView
        {
            get { return _treeView; }
            set { _treeView = value; }
        }
    }
}
