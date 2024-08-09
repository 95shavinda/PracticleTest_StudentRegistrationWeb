export class StudentsSearchRequest {
  constructor(
    public pageNumber: number = 1,
    public pageSize: number = 10,
    public searchText?: string,
    public sortOrder?: string,
    public sortColumn?: string
  ) {}
}
