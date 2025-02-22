using Antivirus.DTOs;

namespace Antivirus.Services
{
    public interface IUbicationInstitutionService
    {
        Task<IEnumerable<UbicationInstitutionResponseDto>> GetAllAsync();
        Task<UbicationInstitutionResponseDto> GetByIdAsync(long id);
        Task<UbicationInstitutionResponseDto> CreateAsync(UbicationInstitutionRequestDto ubicationDto);
        Task<bool> UpdateAsync(long id, UbicationInstitutionRequestDto ubicationDto);
        Task<bool> DeleteAsync(long id);
    }}