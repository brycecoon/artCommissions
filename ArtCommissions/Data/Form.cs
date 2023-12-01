using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace ArtCommissions.Data;

public class Form
{
    PostgresContext context;

    public byte[]? imageBytes { get; private set; } = null;
    public List<CommissionExample> commissionExamples { get; private set; }
    public List<CommissionRequest>? commissionRequests;

    public bool NameIsSelected { get; private set; } = true;
    public bool TypeIsSelected { get; private set; } = true;

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

    public async Task CreateNewRequest()
    {
        if (Name is null)
        {
            NameIsSelected = false;
            return;
        }
        else
        {
            NameIsSelected = true;
        }

        if (SelectedType is null)
        {
            TypeIsSelected = false;
            return;
        }

        var request = new CommissionRequest();

        string[] n = Name.Split(" ");
        request.Firstname = n[0];
        request.Lastname = n.Count() == 1 ? "" : n[1];
        request.Email = Email;
        request.Details = CommissionDetails;
        request.ArtistId = 1;                 /////////////////////////////////HARD CODED VALUE///////////////////////////
        request.CommissionType = SelectedType;

        await context.CommissionRequests.AddAsync(request);
        await context.SaveChangesAsync();
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

    public async Task SaveFileToDatabase(CommissionRequest request)
    {
        try
        {
            ReferenceImage art = new ReferenceImage()
            {
                Image = imageBytes,
                CommissionRequestId = request.Id
            };

            context.Add(art);
            await context.SaveChangesAsync();

            imageBytes = null;
        }
        catch
        {
            ////// Todo: fimx me
        }
    }
}
