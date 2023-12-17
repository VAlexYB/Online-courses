namespace Online_courses_CourseP_.Service
{
    public static class Extensions
    {
        public static string CutController(this string controllerName)
        {
            return controllerName.Replace("Controller", "");
        }
    }
}
