export const API = {
	ignoreConneciton: true,
	connection: {
		protocol: 'http',
		hostName: 'localhost',
		port: '5000',
		apiRoot: 'api',
		endpoints: {
			getToken: 'connect/token',
			getProfiles: 'api/profiles',
			getProfile: 'api/profiles/{profileId}',
			getMyProfile: 'api/profiles/me',
			registerProfile: 'api/profiles',
			updatePersonalProfile: 'api/profiles/me',
			searchProfiles: 'api/profiles/search',
			getSkill: 'api/profiles/skills',
			addSkill: 'api/profiles/{profileId}/skills',
			setSkillScore: 'api/profiles/skills/{skillId}/score',
			getSkillScore: 'api/profiles/skills/{skillId}/score'
		}
	}
};
