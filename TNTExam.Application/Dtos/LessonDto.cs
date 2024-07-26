namespace TNTExam.Application.Dtos
{
	public class LessonDto
	{
        public string Name { get; set; } = string.Empty; //نام درس
		public int? Correct { get; set; } //صحیح
		public int? Wrong { get; set; } //غلط
		public int? NoAnswer { get; set; } //نزده   
		public double? RawScore { get; set; } //نمره خام
	}
}
