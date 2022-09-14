using FluentValidation;

namespace MinimalApi.Features.Author.Signup;

public class Request
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class Response
{
    public string Message { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Your name is required!")
            .MinimumLength(3).WithMessage("Name is too short!")
            .MaximumLength(25).WithMessage("Name is too long!");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email address is required!")
            .EmailAddress().WithMessage("The format of your email address is wrong!");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required!")
            .MinimumLength(3).WithMessage("Username is too short!")
            .MaximumLength(15).WithMessage("Username is too long!");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("a password is required!")
            .MinimumLength(10).WithMessage("password is too short!")
            .MaximumLength(25).WithMessage("password is too long!");
    }
}
