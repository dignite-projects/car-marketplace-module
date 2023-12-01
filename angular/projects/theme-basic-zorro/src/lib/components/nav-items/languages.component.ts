import { ConfigStateService, LanguageInfo, SessionStateService } from '@abp/ng.core';
import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'dig-languages',
  template: `
    <!-- <div
      *ngIf="((dropdownLanguages$ | async)?.length || 0) > 0"
      class="dropdown"
      ngbDropdown
      #languageDropdown="ngbDropdown"
      display="static"
    >
      <a
        ngbDropdownToggle
        class="nav-link"
        href="javascript:void(0)"
        role="button"
        id="dropdownMenuLink"
        data-toggle="dropdown"
        aria-haspopup="true"
        aria-expanded="false"
      >
        {{ defaultLanguage$ | async }}
      </a>
      <div
        class="dropdown-menu dropdown-menu-end border-0 shadow-sm"
        aria-labelledby="dropdownMenuLink"
        [class.d-block]="smallScreen && languageDropdown.isOpen()"
      >
        <a
          *ngFor="let lang of dropdownLanguages$ | async"
          href="javascript:void(0)"
          class="dropdown-item"
          (click)="onChangeLang(lang.cultureName || '')"
          >{{ lang?.displayName }}</a
        >
      </div>
    </div> -->
    <div
      *ngIf="((dropdownLanguages$ | async)?.length || 0) > 0"
      class="dropdown"
      ngbDropdown
      #languageDropdown="ngbDropdown"
      display="static"
    >
      <a
        nz-dropdown
        [nzDropdownMenu]="menu"
        nzTrigger="click"
        class="nav-link"
        href="javascript:void(0)"
        role="button"
      >
        {{ defaultLanguage$ | async }}
        <span nz-icon nzType="caret-down"></span>
      </a>

      <nz-dropdown-menu #menu="nzDropdownMenu">
        <ul nz-menu class="nzDropdownMenu-ul">
          <ng-container *ngFor="let lang of dropdownLanguages$ | async; let i = index">
            <li nz-menu-item (click)="onChangeLang(lang.cultureName || '')">
              {{ lang?.displayName }}
            </li>
          </ng-container>
        </ul>
      </nz-dropdown-menu>
    </div>
  `,
  styles: [
    `
      .nav-link {
        display: flex;
        align-items: center;
        span[nz-icon] {
          font-size: 12px;
        }
      }
      .nzDropdownMenu-ul {
        max-height: 500px;
        overflow: auto;
      }
    `,
  ],
})
export class LanguagesComponent {
  get smallScreen(): boolean {
    return window.innerWidth < 992;
  }

  languages$: Observable<LanguageInfo[]> = this.configState.getDeep$('localization.languages');

  get defaultLanguage$(): Observable<string> {
    return this.languages$.pipe(
      map(
        languages =>
          languages?.find(lang => lang.cultureName === this.selectedLangCulture)?.displayName || ''
      )
    );
  }

  get dropdownLanguages$(): Observable<LanguageInfo[]> {
    return this.languages$.pipe(
      map(
        languages => languages?.filter(lang => lang.cultureName !== this.selectedLangCulture) || []
      )
    );
  }

  get selectedLangCulture(): string {
    return this.sessionState.getLanguage();
  }

  constructor(private sessionState: SessionStateService, private configState: ConfigStateService) { }

  onChangeLang(cultureName: string) {
    this.sessionState.setLanguage(cultureName);
  }
}
