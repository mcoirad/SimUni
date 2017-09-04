using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Datab {
public class DataFrame {

	// TODO: this should be converted to a struct if performance ever becomes an issue

	public List<List<object>> data {get; set;}
	
	public List<string> names {get; set;}
	
	public DataFrame() {
	
	}
	
	// Get number of columns
	public int nCol() {
		return names.Count;
	}
	
	// Get number of rows
	public int nRow() {
		return data.Count;
	}
	
	// Get a 'column' from its name
	public List<object> GetColumn(string colName) {
		int index = names.IndexOf(colName);
		List<object> column = new List<object> ();
		foreach (List<object> cell in data) {
			column.Add(cell[index]);
		}
		return column;
	}
	
	// Get rows if column equal to 'by'
	public List<List<object>> GetRows(string colName, object by) {
		int index = names.IndexOf(colName);
		List<List<object>> rows = new List<List<object>> ();
		foreach (List<object> cell in data) {
			if (cell[index].Equals(by)) {
				rows.Add(cell);
			}
		}
		return rows;
	}
	
	// Get columns by another column equal to 'by'
	public List<object> GetColumnByColumn(string colBy, object by, string colName) {
		int index = names.IndexOf(colBy);
		int returnIndex = names.IndexOf(colName);
		List<object> column = new List<object> ();
		foreach (List<object> cell in data) {
			if (cell[index].Equals(by)) {
				column.Add(cell[returnIndex]);
			}
		}
		return column;
	}
}

}