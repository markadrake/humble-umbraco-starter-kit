using System.Collections.Generic;

namespace Humble.Theme;

public class Typography
{
	public string Label { get; set; }
	public string CSSClassName { get; set; }
	public List<Dictionary<Breakpoint, string>> Values { get; set; }
}