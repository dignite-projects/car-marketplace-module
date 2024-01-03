
import { CommonModule, registerLocaleData } from '@angular/common';
import { AccountConfigModule } from '@abp/ng.account/config';
import { CoreModule } from '@abp/ng.core';
import { registerLocale } from '@abp/ng.core/locale';
import { IdentityConfigModule } from '@abp/ng.identity/config';
import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
import { TenantManagementConfigModule } from '@abp/ng.tenant-management/config';
import { ThemeLeptonXModule } from '@abp/ng.theme.lepton-x';
import { SideMenuLayoutModule } from '@abp/ng.theme.lepton-x/layouts';
import { AccountLayoutModule } from '@abp/ng.theme.lepton-x/account';
import { ThemeSharedModule } from '@abp/ng.theme.shared';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';
import { FeatureManagementModule } from '@abp/ng.feature-management';
import { AbpOAuthModule } from '@abp/ng.oauth';
import { CarMarketplaceAdminConfigModule } from '@dignite/car-marketplace-admin/config';
import { CarMarketplaceDealerPlatformConfigModule } from '@dignite/car-marketplace-dealer-platform/config';
 
 
@NgModule({
  imports: [ 
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule.forRoot({
      environment,
      registerLocaleFn: registerLocale(),
      sendNullsAsQueryParam: false,
      skipGetAppConfiguration: false,
    }),
    AbpOAuthModule.forRoot(), 
    ThemeSharedModule.forRoot(),
    AccountConfigModule.forRoot(),
    IdentityConfigModule.forRoot(),
    TenantManagementConfigModule.forRoot(),
    SettingManagementConfigModule.forRoot(),
    ThemeLeptonXModule.forRoot(),
    SideMenuLayoutModule.forRoot(),
    AccountLayoutModule.forRoot(),
    FeatureManagementModule.forRoot(),
    CarMarketplaceAdminConfigModule.forRoot(),//系统管理导航配置
    CarMarketplaceDealerPlatformConfigModule.forRoot()//车商管理平台导航配置
  ],
  providers: [APP_ROUTE_PROVIDER],
  declarations: [AppComponent],
  bootstrap: [AppComponent],
})
export class AppModule { }
