using eIMIC223925.DATA.Enum;

namespace eIMIC223925.DATA.Entities
{
	public class Slide
	{
		public int Id { set; get; }
		public string Name { set; get; }
		public string Description { set; get; }
		public string Url { set; get; }

		public string Image { get; set; }
		public int SortOrder { get; set; }
		public Status Status { set; get; }
	}
}
