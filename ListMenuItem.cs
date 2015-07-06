using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Drawing;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public class ListMenu : GTA.Menu
{
    public readonly List<IMenuItem> _allItems;
    private readonly int _itemsPerPage;
    private int _currentShift = 0;

    public ListMenu(string headerCaption, IMenuItem[] items, int itemsPerPage)
        : base(headerCaption, items.Take(itemsPerPage).ToArray())
    {
        this._allItems = new List<IMenuItem>();
        this._allItems.AddRange(items);
        foreach (IMenuItem item in this._allItems)
        {
            item.Parent = this;
        }
        this._itemsPerPage = itemsPerPage;
        this.ShowMenu();
    }

    public override void OnChangeItem(bool right)
    {
        if (right && this._currentShift + this._itemsPerPage < this._allItems.Count)
        {
            this.NextPage();
        }
        else if (!right && this._currentShift > 0)
        {
            this.PrevPage();
        }
    }

    private void NextPage()
    {
        if (this._currentShift + this._itemsPerPage < this._allItems.Count)
        {
            this._currentShift += this._itemsPerPage;
        }
        else
        {
            this._currentShift += this._allItems.Count - this._currentShift;
        }
        this.ShowMenu();
    }

    private void PrevPage()
    {
        if (this._currentShift - this._itemsPerPage > 0)
        {
            this._currentShift -= this._itemsPerPage;
        }
        else
        {
            this._currentShift = 0;
        }
        this.ShowMenu();
    }

    private void ShowMenu()
    {
        this.ShowMenu(this._currentShift > 0, this._currentShift + this._itemsPerPage < this._allItems.Count);
        this.Initialize();
    }

    private void ShowMenu(bool showPrevBtn, bool showNextBtn)
    {
        this.Items = this._allItems.Skip(this._currentShift).Take(this._itemsPerPage).ToList();
        if (showPrevBtn)
        {
            var prevBtn = new MenuButton("PrevPage") { Parent = this };
            prevBtn.Activated += (sender, args) => this.PrevPage();
            this.Items.Add(prevBtn);
        }
        if (showNextBtn)
        {
            var nextBtn = new MenuButton("NextPage") { Parent = this };
            nextBtn.Activated += (sender, args) => this.NextPage();
            this.Items.Add(nextBtn);
        }
    }
}