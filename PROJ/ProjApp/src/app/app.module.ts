import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NzCarouselModule } from 'ng-zorro-antd/carousel';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { en_US } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IconsProviderModule } from './icons-provider.module';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzRateModule } from 'ng-zorro-antd/rate';
import { RecommendationComponent } from './recommendation/recommendation.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { FilterPipe } from './filter.pipe';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { SearchAndCompleteSubjectsComponent } from './search-and-complete-subjects/search-and-complete-subjects.component';
import { RateSubjectComponent } from './rate-subject/rate-subject.component';
import { NzFormModule } from 'ng-zorro-antd/form';
import { PreferencesComponent } from './preferences/preferences.component';
import { NzRadioModule } from 'ng-zorro-antd/radio';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { HomepageComponent } from './homepage/homepage.component';
import { NzNotificationModule } from 'ng-zorro-antd/notification';
registerLocaleData(en);

@NgModule({
  declarations: [
    AppComponent,
    RecommendationComponent,
    PageNotFoundComponent,
    FilterPipe,
    PageNotFoundComponent,
    LoginComponent,
    RegisterComponent,
    PreferencesComponent,
    HomepageComponent,
    SearchAndCompleteSubjectsComponent,
    RateSubjectComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    IconsProviderModule,
    NzLayoutModule,
    NzMenuModule,
    NzButtonModule,
    NzRateModule,
    NzSelectModule,
    NzFormModule,
    ReactiveFormsModule,
    NzRadioModule,
    NzCheckboxModule,
    NzSelectModule,
    NzInputModule,
    NzCardModule,
    NzGridModule,
    NzModalModule,
    NzCarouselModule,
    NzNotificationModule
  ],
  providers: [{ provide: NZ_I18N, useValue: en_US }],
  bootstrap: [AppComponent]
})
export class AppModule { }
