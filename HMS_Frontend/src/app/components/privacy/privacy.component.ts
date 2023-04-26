import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-privacy',
  templateUrl: './privacy.component.html',
  styleUrls: ['./privacy.component.css']
})
export class PrivacyComponent implements OnInit {
  public claims: { type: string, value: string }[] = [];

constructor(private repo: RepositoryService){}
  ngOnInit(): void {
    this.getClaims();
  }
  public getClaims = () => {
    this.repo.getClaims('Admin/privacy')
    .subscribe(res => {
      this.claims = res as [];})
  }
}
