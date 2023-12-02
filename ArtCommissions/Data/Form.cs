using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace ArtCommissions.Data;

public class Form
{
    PostgresContext? context = null;

    public byte[]? imageBytes { get; private set; } = null;
    public List<CommissionExample> commissionExamples { get; private set; }
    public List<CommissionRequest>? commissionRequests;

    public bool NameIsSelected { get; private set; } = true;
    public bool TypeIsSelected { get; private set; } = true;
    public bool ValidEmail { get; private set; } = true;

    public string? Name { get; set; } = null;
    public string? SelectedType { get; set; } = null;

    public string Email { get; set; } = "";
    public string CommissionDetails { get; set; } = "";

    public Form(PostgresContext context)
    {
        this.context = context;
        Task.Run(() => this.PopulateExampleTypes()).Wait();

        NameIsSelected = true;
        TypeIsSelected = true;
        Name = null;
        SelectedType = null;
        Email = "";
        CommissionDetails = "";
    }

    public Form()
    {
        
    }

    public async Task CreateNewRequest()
    {
        if (Name is null)
        {
            NameIsSelected = false;
            return;
        }
        else NameIsSelected = true;
        

        if (!EmailVerification())
        {
            ValidEmail = false;
            return;
        }
        else ValidEmail = true;
        

        if (SelectedType is null)
        {
            TypeIsSelected = false;
            return;
        }
        else TypeIsSelected = true;


        var request = new CommissionRequest();

        string[] n = Name.Split(" ");
        request.Firstname = n[0];
        request.Lastname = n.Count() == 1 ? "" : n[1];
        request.Email = Email;
        request.AcceptedStatus = "PENDING";
        request.Details = CommissionDetails;
        request.ArtistId = 1;                 /////////////////////////////////HARD CODED VALUE///////////////////////////
        request.CommissionType = SelectedType;

        await SaveFileToDatabase(request);
    }

    public async Task HandleFileChange(InputFileChangeEventArgs e)
    {
        using (var stream = e.File.OpenReadStream(8000000))
        {
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                imageBytes = memoryStream.ToArray();
            }
        }
    }

    private async Task PopulateExampleTypes()
    {
        commissionExamples = await context.CommissionExamples.ToListAsync();
    }

    private bool EmailVerification()
    {
        if (Email is null || Email.IndexOf('@') < 0)
        {
            ValidEmail = false;
            return false;
        }
        else
        {
            for(int i = Email.IndexOf('@'); i < Email.Length; i++)
            {
                ValidEmail = false;
                if (Email[i] == '.')
                {
                    ValidEmail = true;
                    return true;
                }
            }
            return false;
        }
    }

    public virtual async Task SaveFileToDatabase(CommissionRequest request)
    {
        try
        {
            await context.CommissionRequests.AddAsync(request);

            if (imageBytes != null)
            {
                ReferenceImage art = new ReferenceImage()
                {
                    Image = imageBytes,
                    CommissionRequestId = request.Id
                };

                context.Add(art);
            }
            await context.SaveChangesAsync();

            imageBytes = null;
        }
        catch
        {
            ////// Todo: fimx me help please :(((((( i so sad and don't wanna work
        }
    }
}