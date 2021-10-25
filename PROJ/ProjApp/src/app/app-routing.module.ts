import { AuthGuard } from './auth-guard.guard';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { HomepageComponent } from './homepage/homepage.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { RecommendationComponent } from './recommendation/recommendation.component';
import { SearchAndCompleteSubjectsComponent } from './search-and-complete-subjects/search-and-complete-subjects.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PreferencesComponent } from './preferences/preferences.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/homepage' },
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'preferences', component: PreferencesComponent, canActivate: [AuthGuard]},
  { path: 'homepage', component: HomepageComponent},
  { path: 'recommendation', component: RecommendationComponent, canActivate: [AuthGuard] },
  { path: 'search-and-complete', component: SearchAndCompleteSubjectsComponent },
  { path: '**', component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
