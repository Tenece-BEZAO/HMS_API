
using AutoMapper;
using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using HMS.DAL.Interfaces;

namespace HMS.BLL.Implementation
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Report> _reportRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _reportRepository = _unitOfWork.GetRepository<Report>();
        }


        public async Task<IEnumerable<ReportDto>> GetReportsAsync()
        {
            var reports = await _reportRepository.GetAllAsync(orderBy: q => q.OrderBy(a => a.ReportDate));
            var reportDtos = _mapper.Map<IEnumerable<ReportDto>>(reports);
            return reportDtos;
        }


        public async Task<ReportDto> AddReportAsync(ReportDto reportDto)
        {
            var report = _mapper.Map<Report>(reportDto);

            await _reportRepository.AddAsync(report);
            await _unitOfWork.SaveChangesAsync();

            return reportDto;
        }

        public async Task<IEnumerable<ReportDto>> SearchReportsAsync(string searchTerm)
        {
            var reports = await _reportRepository.GetByAsync(a => a.Name.ToLower().Contains(searchTerm.ToLower()) ||
                                   a.Reason.ToLower().Contains(searchTerm.ToLower()),
                                   orderBy: q => q.OrderBy(r => r.ReportDate));

            var reportDtos = _mapper.Map<IEnumerable<ReportDto>>(reports);
            return reportDtos;
        }


        public async Task DeleteReportAsync(int reportId)
        {
            var report = await _reportRepository.GetByIdAsync(reportId);

            if (report == null)
            {
                throw new ArgumentException("Report not found.");
            }

            await _reportRepository.DeleteAsync(report);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
